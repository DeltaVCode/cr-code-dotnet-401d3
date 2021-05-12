import { createContext, useContext, useState } from 'react';

export const AuthContext = createContext();

export function AuthProvider(props) {
    const [state, setState] = useState({
        user: { name: 'Keith' },
    });

    return (
        <AuthContext.Provider value={state}>
            {props.children}
        </AuthContext.Provider>
    );
}