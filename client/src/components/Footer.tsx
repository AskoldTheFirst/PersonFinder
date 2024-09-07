import { useEffect, useState } from "react"
import http from "../http";

export default function Footer() {
    const [total, setTotal] = useState<number | null>(null);

    useEffect(() => {
        http.Cards.total().then(t => setTotal(t));
    }, []);

    if (total == null)
        return <></>;

    return (
        <>
            <div style={{background: '#F8F9FA', minHeight: '60px', textAlign: 'right', paddingRight: 12, paddingTop: 2, marginTop: 28}}>
                <span style={{fontSize: 10, fontStyle: 'italic'}}>active cards: {total}</span>
                <span style={{fontSize: 10, fontStyle: 'italic', display: 'block'}}>registered: 2</span>
            </div>
        </>
    )
}