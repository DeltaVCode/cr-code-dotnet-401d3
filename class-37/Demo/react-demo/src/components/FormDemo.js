import { useState } from "react";

export default function FormDemo(){
    return (
        <>
            <Counter initialValue={3.14159} />
            <Counter title="Counter, Too" />
            <FormUncontrolledDemo />
        </>
    )
}

function Counter(props)
{
    const { initialValue, title } = props;

    let [num, setNum] = useState(initialValue || 0);
    console.log('calling Counter', num);

    const increment = (event) => {
        // num++;
        // console.log(num);
        setNum(num + 1);

        num = 7;
        console.log(num);
    }

    const handleChange = event => {
        setNum(parseInt(event.target.value));
    }

    return (
        <form>
            <h3>{title || 'Counter Value'}: {num}</h3>
            <input type="text" value={num}
                onChange={handleChange} />
            <button type='button' onClick={increment}>+1</button>
        </form>
    )
}

function FormUncontrolledDemo(){
    const handleSubmit = e => {
        e.preventDefault();

        const { target } = e;

        console.log(target.word.value);
        target.reset();
    };

    return (
        <form onSubmit={handleSubmit}>
            <h3>Uncontrolled!</h3>
            <input type="text" name="word" />
            <Counter title="inside form!" />
        </form>
    )
}