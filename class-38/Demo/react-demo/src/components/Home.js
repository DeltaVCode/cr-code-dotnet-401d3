import { useState } from 'react';
import Auth from './auth'; // works because index.js
import './Home.css';

const deltav = [
    { name: 'Keith' },
    { name: 'Stacey' },
    { name: 'Craig' },
    { name: 'Aaron' },
    { name: 'Andy' }
];

export default function Home(){
    const [peeps, setPeeps] = useState(deltav);

    const handleSave = (peep) => {
        // DO NOT USE peeps.push(peep);

        // setPeeps(peeps.concat(peep));

        setPeeps([peep, ...peeps]);
    }

    return (
        <div>
            <h1>Welcome Home!</h1>
            <Auth>
                You are authorized!
            </Auth>
            <PeopleForm peeps={peeps} onSave={handleSave} />
            <PeopleList people={peeps} color='blue' fun />
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
                <PersonItem person={person} key={i} />
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