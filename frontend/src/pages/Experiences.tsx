// import { useState } from "react";
import styles from "./Experiences.module.css";
import { ExperienceCard } from "../components/experiences/ExperienceCard";
import { CxOption, CxSelect } from "@computas/designsystem/select/react";

import { experienceTypeMap } from "../types/experienceTypes";
import { useExperiences } from "../hooks/useExperiences";
import { useState } from "react";

export default function Experiences() {
  const [selectedExperience, setSelectedExperience] = useState<string | null>(
    null
  );

  const { data: experiences, isLoading, error } = useExperiences();

  isLoading && <div className={styles.loading}>Loading...</div>;
  error && <div className={styles.error}>Error: {error.message}</div>;

  if (!experiences || experiences.length === 0) {
    return <div className={styles.noExperiences}>No experiences found.</div>;
  }

  const handleSelectChange = (e: Event) => {
    const customEvent = e as CustomEvent;
    const selectedFilter = customEvent.detail.value;
    console.log(selectedFilter);
    // TODO Oppgave 5.1: Filtrer experiences etter type
    setSelectedExperience(selectedFilter);
  };

  const filteredExperiences = () => {
    const validTypes = Object.keys(experienceTypeMap).filter(
      (type) => type !== "other"
    );

    if (selectedExperience === "other") {
      return experiences.filter(
        (experience) => !validTypes.includes(experience.type.toLowerCase())
      );
    } else if (selectedExperience) {
      return experiences.filter(
        (experience) =>
          experience.type.toLowerCase() === selectedExperience.toLowerCase()
      );
    }
    return experiences;
  };

  return (
    <div className={styles.container}>
      <div className={styles.select}>
        <label className="cx-form-field">
          <div className="cx-form-field__input-container">
            <CxSelect onChange={handleSelectChange}>
              <CxOption value="">Ingen filtrering</CxOption>
              {Object.entries(experienceTypeMap).map(([type, data]) => (
                <CxOption key={type} value={type}>
                  {data.text}
                </CxOption>
              ))}
            </CxSelect>
          </div>
        </label>
      </div>
      <div className={styles.experiences}>
        {filteredExperiences()
          .sort((a, b) => new Date(b.startDate).getTime() - new Date(a.startDate).getTime())
          .map((experience) => (
            <ExperienceCard key={experience.id} experience={experience} />
          ))}
      </div>
    </div>
  );
}
