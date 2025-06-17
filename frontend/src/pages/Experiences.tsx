// import { useState } from "react";
// import styles from "./Experiences.module.css";
// // import { ExperienceCard } from "../components/experiences/ExperienceCard";
// import { CxOption, CxSelect } from "@computas/designsystem/select/react";
// import { experienceTypeMap } from "../types/experienceTypes";
// import { useExperiences } from "../hooks/useExperiences";

export default function Experiences() {
  // const [selectedExperience, setSelectedExperience] = useState<string | null>(
  //   null
  // );


  // TODO Oppgave 2.1 of 2.2: Håndter loading og error av erfaringer
  // const { data: experiences, isLoading: isExperiencesLoading, error: experiencesError} = useExperiences();


  // if (!experiences || experiences.length === 0) {
  //   return <div className={styles.noExperiences}>No experiences found.</div>;
  // }

  const handleSelectChange = (e: Event) => {
    const customEvent = e as CustomEvent;
    const selectedFilter = customEvent.detail.value;
    console.log(selectedFilter);
    // TODO Oppgave 5.1: Filtrer experiences etter type
  };

  // const filteredExperiences = () => {
  //   const validTypes = Object.keys(experienceTypeMap).filter(
  //     (type) => type !== "other"
  //   );

  //   if (selectedExperience === "other") {
  //     return experiences.filter(
  //       (experience) => !validTypes.includes(experience.type.toLowerCase())
  //     );
  //   } else if (selectedExperience) {
  //     return experiences.filter(
  //       (experience) =>
  //         experience.type.toLowerCase() === selectedExperience.toLowerCase()
  //     );
  //   }
  //   return experiences;
  // };

}
