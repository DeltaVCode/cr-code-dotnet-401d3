import { NavLink } from 'react-router-dom';
import { useAuth } from '../contexts/auth';

export default function NavLogin(props) {
    const auth = useAuth();
    console.log(auth);
    const { user } = auth;
    console.log(user);

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