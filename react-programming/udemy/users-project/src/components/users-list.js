import Card from "./card";

import styles from "./styles.module.css";

const UsersList = ({ users }) => {
  return (
    <Card className={styles.users}>
      <ul>
        {users &&
          users.map((user, i) => (
            <li key={i}>
              {user.name} ({user.age} years old)
            </li>
          ))}
      </ul>
    </Card>
  );
};

export default UsersList;
