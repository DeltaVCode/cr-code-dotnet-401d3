import {useEffect, useState} from 'react';
import { useAuth } from '../contexts/auth';

export default function useFetch(url) {
    const { user } = useAuth();

    useEffect(() => {
        console.log('Run always');
        document.title = 'Updated at ' + new Date();
    });

    const [shouldFetch, setShouldFetch] = useState(true);
    const [data, setData] = useState(null);

    useEffect(() => {
        // We should not fetch; do nothing
        if (!shouldFetch) return;

        async function doFetch() {
            console.log('fetching!');
            let headers = {};

            if (user){
                headers['Authorization'] = `Bearer ${user.token}`;
            }

            let response = await fetch(url, {headers});
            let body = await response.json();
            setData(body);

        }

        setShouldFetch(false);
        doFetch();

    }, [url, shouldFetch, user]);

    useEffect(() => {
        console.log('Run once');
    }, []);

    function reload(showLoading) {
        setShouldFetch(true);

        if (showLoading){
            setData(null);
        }
    }

    return {
        data,
        reload,
    };
}