import {useEffect, useState} from 'react';

export default function useFetch(url) {
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
            let response = await fetch(url);
            let body = await response.json();
            setData(body);

        }

        setShouldFetch(false);
        doFetch();

    }, [url, shouldFetch]);

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