import { useEffect, useState } from "react";
import http from "../../http";
import { CardDto } from "../../DTOs/CardDto";
import SearchCard from "./SearchCard";

export default function CardsView() {
    const [cards, setCards] = useState<CardDto[]>([]);

    useEffect(() => {
        http.Cards.cards().then(cards => setCards(cards));
    }, []);

    if (cards == null || cards.length == 0)
        return <></>;
    
    return (
        <>
            {cards.map((card, index) => (
                <SearchCard id={index} card={card} />
            ))}
        </>
    );
}