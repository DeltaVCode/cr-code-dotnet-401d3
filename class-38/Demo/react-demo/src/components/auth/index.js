import { useAuth } from '../../contexts/auth';

export default function Auth(props)
{
    const { children } = props;
    const { user } = useAuth();

    if (!user) return null;

    return children;
}