import {useEffect, useState} from 'react';

export default function useFetch(url) {
    useEffect(() => {
        console.log('Run always');
        document.title = 'Updated at ' + new Date();
    });

    const [data, setData] = useState(null);

    useEffect(() => {
        async function doFetch() {
            console.log('fetching!');
            let response = await fetch(url);
            let body = await response.json();
            setData(body);
        }

        doFetch();
    }, [url]);

    useEffect(() => {
        console.log('Run once');
    }, []);

    return {
        data,
    };
}