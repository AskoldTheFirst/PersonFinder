import { useState } from "react";
import { Form, Row, Col, InputGroup, Button, ListGroup, Table } from "react-bootstrap";
import SearchResult from "./SerachResult";

export default function Main() {
    const [validated, setValidated] = useState(false);
    const [abilitySelectedNumber, setAbilitySelectedNumber] = useState<number>(1);
    const [locationSelectedNumber, setLocationSelectedNumber] = useState<number>(1);

    const handleSubmit = (event: any) => {
        const form = event.currentTarget;
        if (form.checkValidity() === false) {
            event.preventDefault();
            event.stopPropagation();
        }

        setValidated(true);
    };

    const handleAbilityCheckChanged = (event: any) => {
        switch (event.target.id) {
            case "ability-1":
                setAbilitySelectedNumber(1);
                break;
            case "ability-2":
                setAbilitySelectedNumber(2);
                break;
            case "ability-3":
                setAbilitySelectedNumber(3);
                break;
        }
    }

    const handleLocationCheckChanged = (event: any) => {
        switch (event.target.id) {
            case "location-1":
                setLocationSelectedNumber(1);
                break;
            case "location-2":
                setLocationSelectedNumber(2);
                break;
        }
    }

    return (
        <>
            <span style={{ color: 'midnightblue', fontSize: 20 }}>I am searching for a Person:</span>
            <hr />
            {/* ------------- Ability ----------- */}
            <center>
                <Form className="mmm" noValidate validated={validated} onSubmit={handleSubmit}>
                    <Table>
                        <tr>
                            <td width={'20%'} rowSpan={3}><center><span>who</span></center></td>
                            <td width={'30%'} rowSpan={3} style={{ paddingLeft: "18px" }}>

                                <Form.Check
                                    label="can teach "
                                    type="radio"
                                    name="abilityGroup"
                                    id="ability-1"
                                    checked={abilitySelectedNumber == 1}
                                    onChange={handleAbilityCheckChanged}
                                />
                                <Form.Check
                                    label="wants to learn "
                                    type="radio"
                                    name="abilityGroup"
                                    id="ability-2"
                                    checked={abilitySelectedNumber == 2}
                                    onChange={handleAbilityCheckChanged}
                                />
                                <Form.Check
                                    label="is interested in "
                                    type="radio"
                                    name="abilityGroup"
                                    id="ability-3"
                                    checked={abilitySelectedNumber == 3}
                                    onChange={handleAbilityCheckChanged}
                                />

                            </td>
                            <td width={'20%'} rowSpan={3}>
                                <Form.Control
                                    required
                                    type="text"
                                    placeholder="keyword;keyword;keyword"
                                    defaultValue=""
                                />
                            </td>
                        </tr>
                    </Table>
                    <hr />

                    {/* ------------- Location ----------- */}
                    <Table>
                        <tr>
                            <td width={'20%'}><center><span>who</span></center></td>
                            <td width={'30%'}><span>is located</span></td>
                            <td width={'20%'} style={{ paddingLeft: "18px" }}>
                                <Form.Check
                                    label="Anywhere"
                                    type="radio"
                                    name="locationGroup"
                                    id="location-1"
                                    checked={locationSelectedNumber == 1}
                                    onChange={handleLocationCheckChanged}
                                />
                                <Form.Check
                                    label="Specify"
                                    type="radio"
                                    name="locationGroup"
                                    id="location-2"
                                    checked={locationSelectedNumber == 2}
                                    onChange={handleLocationCheckChanged}
                                />
                            </td>
                        </tr>
                    </Table>
                    <hr />

                    {/* ------------- Language ----------- */}
                    <Table>
                        <tr>
                            <td width={'20%'}><center><span>who</span></center></td>
                            <td width={'30%'}><span>can speak</span></td>
                            <td width={'20%'}>
                                <Form.Select aria-label="Default select example">
                                    <option value="1">English</option>
                                    <option value="2">Russia</option>
                                    <option value="3">Spain</option>
                                    <option value="4">China</option>
                                </Form.Select>
                            </td>
                        </tr>
                    </Table>
                    <hr />

                    {/* ------------- Age ----------- */}
                    <Table>
                        <tr>
                            <td width={'20%'}><center><span>whose</span></center></td>
                            <td width={'30%'}><span>age is</span></td>
                            <td width={'20%'}>
                                <Form.Select aria-label="">
                                    <option value="1">No matter</option>
                                    <option value="2">Adolescent</option>
                                    <option value="3">Middle-aged</option>
                                    <option value="4">Senior</option>
                                </Form.Select>
                            </td>
                        </tr>
                    </Table>
                    <hr />
                </Form>
            </center>
            <Button>Search</Button>
            <SearchResult />
        </>
    );
}