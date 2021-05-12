import Alert from 'react-bootstrap/Alert';
import Button from 'react-bootstrap/Button';
import { useAuth } from '../contexts/auth';


export default function BootstrapDemo()
{
    const { user } = useAuth();

    // <> is a React.Fragment
    return (
        <>
            <h1>Bootstrap demo goes here!</h1>
            <Alert variant="danger">Our first alert, {user.name}!</Alert>

            <Button variant="danger">Hi!</Button>
        </>
    )
}