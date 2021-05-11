import { useState } from "react";

export default function FormDemo(){
    return (
        <>
            <Counter />
            <FormUncontrolledDemo />
        </>
    )
}

function Counter()
{
    let [num, setNum] = useState(8);
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
            <h3>Counter Value: {num}</h3>
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
        </form>
    )
}