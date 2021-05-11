export default function FormUncontrolledDemo(){
    const handleSubmit = e => {
        e.preventDefault();

        const { target } = e;

        console.log(target.word.value);
        target.reset();
    };

    return (
        <form onSubmit={handleSubmit}>
            <input type="text" name="word" />
        </form>
    )
}