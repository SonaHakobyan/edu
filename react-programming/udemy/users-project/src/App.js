import React, { useState } from "react";
import UserForm from "./components/add-user";
import UsersList from "./components/users-list";

const App = () => {
  const [users, setUsers] = useState([]);

  const handleAddUser = (user) => {
    setUsers((prevState) => {
      return [...prevState, user];
    });
  };

  return (
    <div>
      <UserForm onAddUser={handleAddUser} />
      <UsersList users={users} />
    </div>
  );
};

export default App;
