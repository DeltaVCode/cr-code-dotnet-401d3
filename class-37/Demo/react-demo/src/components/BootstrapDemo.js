import Alert from 'react-bootstrap/Alert';
import Button from 'react-bootstrap/Button';

export default function BootstrapDemo()
{
    // <> is a React.Fragment
    return (
        <>
            <h1>Bootstrap demo goes here!</h1>
            <Alert variant="danger">Our first alert!</Alert>

            <Button variant="danger">Hi!</Button>
        </>
    )
}