import { createContext, useContext, useState } from 'react';

export const AuthContext = createContext();

export function useAuth() {
    const auth = useContext(AuthContext);
    if (!auth) throw new Error('You forgot AuthProvider!');
    return auth;
}

export function AuthProvider(props) {
    const [state, setState] = useState({
        user: null
    });

    return (
        <AuthContext.Provider value={state}>
            {props.children}
        </AuthContext.Provider>
    );
}