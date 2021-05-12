import { useAuth } from '../../contexts/auth';

export default function Auth(props)
{
    const { children, permission } = props;
    const { user } = useAuth();

    if (!user) return null;

    if (permission) {
        if (user.permissions.includes(permission)) {
            return children;
        } else {
            return null;
        }
    }

    return children;
}