
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
    let num = 5;
    const increment = (event) => {
        num++;
        console.log(num);
    }

    return (
        <form>
            <h3>Counter Value: {num}</h3>
            <input type="text" value={num} />
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