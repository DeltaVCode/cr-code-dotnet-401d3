import Spinner from 'react-bootstrap/Spinner'
import Badge from 'react-bootstrap/Badge';
import useFetch from '../hooks/useFetch';
import { useAuth } from '../contexts/auth';

const api = 'https://deltav-todo.azurewebsites.net/api/v1/Todos';

export default function Tasks()
{
    const { user } = useAuth();
    const { data } = useFetch(api);

    if (!data) {
        return (
            <Spinner animation="border" role="status">
                <span className="sr-only">Loading...</span>
            </Spinner>
        )
    }

    async function toggleCompleted(task)
    {
        // can't toggle if not logged in
        if (!user) return;

        console.log(task);
        let response = await fetch(
            `${api}/${task.id}`,
            {
                method: 'put',
                headers: {
                    'Authorization': `Bearer ${user.token}`,
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify({
                    ...task,
                    completed: !task.completed,
                })
            }
        )

        if (!response.ok) {
            console.warn('Oops!');
        }
    }

    return (
        <>
            <h1>Tasks</h1>
            {data.map(task => (
                <h2 key={task.id}>
                    {task.title}
                    {' '}
                    <span onClick={() => toggleCompleted(task)}>
                        {task.completed ? 'Completed' : 'Pending'}
                    </span>
                </h2>
            ))}
        </>
    )
}