import React, { useState } from "react";
import ErrorModal from "./error-modal"
import "./user-form.css";
import UsersList from "./users-list";

const UserForm = () => {
    const [username, setUsername] = useState("");
    const [age, setAge] = useState("");
    const [message, setMessage] = useState("");
    const [valid, setValid] = useState(true);
    const [users, setUsers] = useState([]);

    const onUsernameChange = event => {
        setUsername(event.target.value);
    }

    const onAgeChange = event => {
        setAge(event.target.value);
    }

    const onFormSubmit = event => {
        event.preventDefault();

        if (username.trim().length == 0 || isNaN(age) || age < 0) {
            setValid(false);
            return;
        }

        setValid(true);
        setUsers((prevState) => {
            return [...prevState, { username, age }];
        })
    }

    return (
        <div>
            <form onSubmit={onFormSubmit}>
                <div className="form-control">
                    <label>Username</label>
                    <input type="text" value={username} onChange={onUsernameChange} />
                    <label>Age (Years)</label>
                    <input type="text" value={age} onChange={onAgeChange} />
                </div>
                <button type="submit" onClick={onFormSubmit}>Add User</button>
            </form>
            <UsersList users={users} />
            {/* <ErrorModal show={!valid} message={message} /> */}
        </div>
    );
}

export default UserForm;