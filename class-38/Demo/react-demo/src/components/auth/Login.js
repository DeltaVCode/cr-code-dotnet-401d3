import { useAuth } from '../../contexts/auth';

export default function Login() {
    const { login } = useAuth();

    const handleSubmit = e => {
        e.preventDefault();

        const { target } = e;
        const { username, password } = target.elements;


        login(username.value, password.value);
    };

    return (
        <form onSubmit={handleSubmit}>
          <label>Username <input type="text" name="username" /></label>
          <label>Password <input type="password" name="password" /></label>
          <button>Log In</button>
        </form>
      );
}