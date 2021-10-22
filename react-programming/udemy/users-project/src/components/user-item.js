const UserItem = props => {
    const bio = `${props.user.username} (${props.user.age} years old)`;

    return (
        <text className="item-control">{bio}</text>
    );
}

export default UserItem;