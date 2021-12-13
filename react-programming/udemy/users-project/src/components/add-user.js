import React, { useState, useRef } from "react";
import Card from "./card";
import Button from "./button";
import ErrorModal from "./error-modal";

import styles from "./styles.module.css";

const UserForm = (props) => {
  const nameInputRef = useRef();
  const ageInputRef = useRef();

  const [error, setError] = useState({ any: false });

  const onFormSubmit = (event) => {
    event.preventDefault();
    const username = nameInputRef.current.value;
    const age = ageInputRef.current.value;

    if (
      username.trim().length === 0 ||
      age.trim().length === 0 ||
      isNaN(age) ||
      age < 1
    ) {
      setError({
        any: true,
        title: "Invalid input",
        message: "Please enter a valid name and age (non-empty values)",
      });

      nameInputRef.current.value = "";
      ageInputRef.current.value = "";
      return;
    }

    setError({ any: false });
    props.onAddUser({ name: username, age });
  };

  const onModalClose = () => {
    setError({ any: false });
  };

  return (
    <div>
      {error.any && (
        <ErrorModal
          title={error.title}
          message={error.message}
          handleClose={onModalClose}
        />
      )}
      <Card className={styles.input}>
        <form onSubmit={onFormSubmit}>
          <label htmlFor="username">Username</label>
          <input type="text" id="username" ref={nameInputRef} />
          <label htmlFor="age" id="age">
            Age (Years)
          </label>
          <input type="text" ref={ageInputRef} />
          <Button type="submit">Add User</Button>
        </form>
      </Card>
    </div>
  );
};

export default UserForm;
