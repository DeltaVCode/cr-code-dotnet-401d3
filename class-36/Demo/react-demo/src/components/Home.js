import './Home.css';

const deltav = [
    { name: 'Keith' },
    { name: 'Stacey' },
    { name: 'Craig' },
    { name: 'Aaron' },
    { name: 'Andy' }
];

export default function Home(){
    return (
        <div>
            <h1>Welcome Home!</h1>
            <PeopleList people={deltav} color='blue' fun />
        </div>
    )
}

// component names *have to* be capitalized
function PeopleList(props) {
    // console.log(props);
    const { people, color, fun } = props; // destructuring
    console.log(color)

    if (!fun) {
        return null;
    }

    return (
        <ul>
            {people.map(person => (
                <PersonItem person={person} />
            ))}
        </ul>
    )
}

function PersonItem(props)
{
    const { person } = props;

    const liClassName = personClassName(person);

    return (
        <li className={liClassName}>
            {person.name}
        </li>
    );
}

function personClassName(person)
{
    if (person.name.length > 4)
        return 'danger';

    return 'benign';
}