import Card from 'react-bootstrap/Card';
import KeyWord from './KeyWord';
import { Button, Table } from 'react-bootstrap';
import { CardDto } from '../../DTOs/CardDto';

interface Props {
    card: CardDto;
    id: number;
}

export default function SearchCard({ card, id }: Props) {
    //console.log(`Id: ${id}`);

    let title = '';
    let color = '';
    switch (card.abilityChoice) {
        case 1:
            title = 'I CAN TEACH';
            color = 'primary';
            break;
        case 2:
            title = 'I WANT LEARN';
            color = 'secondary';
            break;
        case 3:
            title = 'I AM INTERESTED IN';
            color = 'success';
            break;
        default:
            throw `wrong ability code! ${card.abilityChoice}`;
    }

    let keywords = card.abilityKeyWords.split(';');
    let location = card.locationChoice == 1 ? 'Anywhere' : card.locationCountry + ', ' + card.locationRegion;

    return (
        <>
            <Card
                key={id}
                bg={color}
                text={''}
                style={{ width: '18rem' }}
                className="mb-2"
            >
                <Card.Header>Header</Card.Header>
                <Card.Body>
                    <Card.Title>{title} Card Title </Card.Title>
                    {keywords.map((k, i) => <KeyWord id={`${id}-${i}`} keyword={k} />)}
                    <Table>
                        <thead />
                        <tbody>
                            <tr>
                                <td>Location:</td>
                                <td>{location}</td>
                            </tr>
                            <tr>
                                <td>Language:</td>
                                <td>{card.languageChoice}</td>
                            </tr>
                            <tr>
                                <td>Age:</td>
                                <td>{card.ageChoice}</td>
                            </tr>
                            <tr>
                                <td>Expired:</td>
                                <td>{card.expirationDate}</td>
                            </tr>
                            <tr>
                                <td>Is Active:</td>
                                <td>{card.isActive ? 'Yes' : 'No'}</td>
                            </tr>
                        </tbody>
                    </Table>

                    <Button>Search</Button>
                </Card.Body>
            </Card>
        </>
    );
}