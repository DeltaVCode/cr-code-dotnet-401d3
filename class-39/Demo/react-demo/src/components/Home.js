import { useState } from 'react';
import Button from 'react-bootstrap/Button';
import Auth from './auth'; // works because index.js
import './Home.css';

const deltav = [
    { name: 'Keith' },
    { name: 'Stacey' },
    { name: 'Craig' },
    { name: 'Aaron', danger: true },
    { name: 'Andy' }
];

export default function Home(){
    const [peeps, setPeeps] = useState(deltav);

    const handleSave = (peep) => {
        // DO NOT USE peeps.push(peep);

        // setPeeps(peeps.concat(peep));

        setPeeps([peep, ...peeps]);
    }

    function handleToggleDangerous(toggledPerson) {
        console.log('toggling', toggledPerson.name)

        const newPeeps = peeps
            .map(p => {
                if (p === toggledPerson) {
                    return {
                        ...toggledPerson,
                        danger: !toggledPerson.danger,
                        toggledAt: new Date(),
                    };
                }

                return p;
            });
            console.log(newPeeps);

        setPeeps(newPeeps);
    }

    return (
        <div>
            <h1>Welcome Home!</h1>
            <Auth>
                You are authorized!
            </Auth>

            <Auth permission='create'>
                <PeopleForm peeps={peeps} onSave={handleSave} />
            </Auth>

            <PeopleList people={peeps} color='blue' fun
                onToggleDangerous={handleToggleDangerous} />
        </div>
    )
}

function PeopleForm(props){
    const [name, setName] = useState('');
    const [danger, setDanger] = useState(true);

    console.log({ name, danger })

    const { peeps, onSave } = props;
    console.log('peeps', peeps);

    const handleNameChange = e => setName(e.target.value);
    const handleDangerChange = e => setDanger(e.target.checked);

    const handleSubmit = e => {
        e.preventDefault();
        
        console.log('submit', { name, danger})

        const newPeep = { name, danger, saved: true };
        onSave(newPeep); // function from props

        // Doesn't work!
        // peeps.push({ name, danger });
        // console.log(peeps);
    }

    return (
        <form onSubmit={handleSubmit}>
            <input name="name" placeholder="Name"
                value={name} onChange={handleNameChange} />
            <label>
                Dangerous? 
                <input type="checkbox" name="dangerous" value="yes"
                    checked={danger} onChange={handleDangerChange} />
            </label>
            <button>Add Peep</button>
        </form>
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
            {people.map((person, i) => (
                <PersonItem person={person} key={i}
                    onToggle={props.onToggleDangerous} />
            ))}
        </ul>
    )
}

function PersonItem(props)
{
    const { person, onToggle } = props;

    const liClassName = personClassName(person);

    const buttonText = person.danger ? 'NOT DANGEROUS NOW' : 'DANGER!!!!';

    function toggleDanger(){
        onToggle(person);
    }

    return (
        <li className={liClassName}>
            {person.name}

            <Button onClick={toggleDanger}>
                {buttonText}
            </Button>
        </li>
    );
}

function personClassName(person)
{
    if (person.danger)
        return 'danger';

    return 'benign';
}