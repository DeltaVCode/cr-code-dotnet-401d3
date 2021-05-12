import { createContext, useContext, useState } from 'react';

// Normally get this from our environment
const usersAPI = 'https://deltav-todo.azurewebsites.net/api/v1/Users';

export const AuthContext = createContext();

export function useAuth() {
    const auth = useContext(AuthContext);
    if (!auth) throw new Error('You forgot AuthProvider!');
    return auth;
}

export function AuthProvider(props) {
    const [state, setState] = useState({
        user: null,

        login,
        logout,
    });

    async function login(username, password) {
        console.log({username, password});

        const result = await fetch(`${usersAPI}/Login`, {
            method: 'post',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ username, password }),
        });

        const resultBody = await result.json();
        console.log({resultBody});

        if (result.ok) {
            return setUser(resultBody);
        }

        // TODO: process validation errors

        // Make sure we're not logged in!
        return logout();
    }

    function logout() {
        return setUser(null);
    }

    function setUser(user) {
        setState(prevState => ({
            ...prevState, // spread operator
            user,
        }));
        return true;
    }

    return (
        <AuthContext.Provider value={state}>
            {props.children}
        </AuthContext.Provider>
    );
}