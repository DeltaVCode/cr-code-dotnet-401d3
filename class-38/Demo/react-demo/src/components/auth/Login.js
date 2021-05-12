export default function Login() {

    const handleSubmit = e => {
        e.preventDefault();
    };

    return (
        <form onSubmit={handleSubmit}>
          <label>Username <input type="text" name="username" /></label>
          <label>Password <input type="password" name="password" /></label>
          <button>Log In</button>
        </form>
      );
}