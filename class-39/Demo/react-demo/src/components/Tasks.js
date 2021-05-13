import Spinner from 'react-bootstrap/Spinner'
import useFetch from '../hooks/useFetch';
const api = 'https://deltav-todo.azurewebsites.net/api/v1/Todos';

export default function Tasks()
{
    const { data } = useFetch(api);

    if (!data) {
        return (
            <Spinner animation="border" role="status">
                <span className="sr-only">Loading...</span>
            </Spinner>
        )
    }

    return (
        <>
            <h1>Tasks</h1>
            {data.map(task => (
                <h2 key={task.id}>{task.title}</h2>
            ))}
        </>
    )
}