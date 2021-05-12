import { NavLink } from 'react-router-dom';

export default function NavLogin(props) {
    const { user } = props;

    if (user) {
        return (
            <li>Hi, {user.name}</li>
        );
    }

    return (
        <>
          <li><NavLink to="/login">Login</NavLink></li>
          <li><NavLink to="/register">Register</NavLink></li>
        </>
    )
}