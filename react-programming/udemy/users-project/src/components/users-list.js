import UserItem from "./user-item";

const UsersList = props => {
    const { users } = props;

    return (
        users && users.map((user, i) => <UserItem key={i} user={user} />)
    );
}

export default UsersList;