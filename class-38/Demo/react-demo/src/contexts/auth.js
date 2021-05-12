import { createContext, useContext, useState } from 'react';
import jwt from 'jsonwebtoken';

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
        // pull permissions out of token
        user = processToken(user);

        setState(prevState => ({
            ...prevState, // spread operator
            user,
        }));
        return user;
    }

    return (
        <AuthContext.Provider value={state}>
            {props.children}
        </AuthContext.Provider>
    );
}

function processToken(user) {
    if (!user)
      return null;
  
    try {
      const payload = jwt.decode(user.token);
      if (payload){
        console.log('token payload', payload);
        user.permissions = payload.permissions || [];
        return user;
      }
  
      return null;
    }
    catch (e) {
      console.warn(e);
      return null;
    }
  }
