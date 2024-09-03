import { useState } from "react";
import { Form, Row, Col, InputGroup, Button, ListGroup, Table } from "react-bootstrap";
import SearchResult from "./SerachResult";
import { SearchEntity } from "../../Entities/SearchEntity";

export default function Main() {
    const [validated, setValidated] = useState(false);
    const [searchState, setSearchState] = useState<SearchEntity>(new SearchEntity());

    const handleSubmit = (event: any) => {
        const form = event.currentTarget;
        
        let clonedState = Object.assign({}, searchState);

        clonedState.isAbilityValid = clonedState.abilityKeyWords.length > 0;
        clonedState.isCountryValid = clonedState.locationId == 2 && clonedState.country.length > 0;
        clonedState.isRegionValid = clonedState.locationId == 2 && clonedState.region.length > 0;

        setSearchState(clonedState);
        

        // if (form.checkValidity() === false) {
        //     event.preventDefault();
        //     event.stopPropagation();
        // }

        // setValidated(true);
    };

    const handleAbilityCheckChanged = (event: any) => {
        let clonedState = Object.assign({}, searchState);

        // [TODO] - Why does not it work?
        //let clonedState = { ...searchState };

        switch (event.target.id) {
            case "ability-1":
                clonedState.abilityId = 1;
                break;
            case "ability-2":
                clonedState.abilityId = 2;
                break;
            case "ability-3":
                clonedState.abilityId = 3;
                break;
        }

        setSearchState(clonedState);
    }

    const handleLocationCheckChanged = (event: any) => {
        let clonedState = Object.assign({}, searchState);

        switch (event.target.id) {
            case "location-1":
                clonedState.locationId = 1;
                break;
            case "location-2":
                clonedState.locationId = 2;
                break;
        }

        setSearchState(clonedState);
    }

    return (
        <>
            <span style={{ color: 'midnightblue', fontSize: 20 }}>I am searching for a Person:</span>
            <hr />
            {/* ------------- Ability ----------- */}
            {/* [TODO] <center> Is this the correct way to center the content? */}
            <center>
                <Form className="mmm">
                    <Table>
                        <tr>
                            {/* [TODO] How to shrink the middle column? */}
                            <td width={'20%'} rowSpan={3}><center><span>who</span></center></td>
                            <td width={'30%'} rowSpan={3} style={{ paddingLeft: "18px" }}>

                                <Form.Check
                                    label="can teach "
                                    type="radio"
                                    name="abilityGroup"
                                    id="ability-1"
                                    checked={searchState.abilityId == 1}
                                    onChange={handleAbilityCheckChanged}
                                />
                                <Form.Check
                                    label="wants to learn "
                                    type="radio"
                                    name="abilityGroup"
                                    id="ability-2"
                                    checked={searchState.abilityId == 2}
                                    onChange={handleAbilityCheckChanged}
                                />
                                <Form.Check
                                    label="is interested in "
                                    type="radio"
                                    name="abilityGroup"
                                    id="ability-3"
                                    checked={searchState.abilityId == 3}
                                    onChange={handleAbilityCheckChanged}
                                />

                            </td>
                            <td width={'20%'} rowSpan={3}>
                                <Form.Control
                                    required
                                    type="text"
                                    //placeholder="keyword;keyword;keyword"
                                    value={searchState.abilityKeyWords}
                                    isInvalid={!searchState.isAbilityValid}
                                    onChange={(e: any) => {
                                        let clonedState = Object.assign({}, searchState);
                                        clonedState.abilityKeyWords = e.target.value;
                                        clonedState.isAbilityValid = clonedState.abilityKeyWords.length > 0;
                                        setSearchState(clonedState);
                                    }}
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
                                    checked={searchState.locationId == 1}
                                    onChange={handleLocationCheckChanged}
                                />
                                <Form.Check
                                    label="Specify"
                                    type="radio"
                                    name="locationGroup"
                                    id="location-2"
                                    checked={searchState.locationId == 2}
                                    onChange={handleLocationCheckChanged}
                                />
                                <Form.Group controlId="countryCtr">
                                    <Form.Label>Country:</Form.Label>
                                    <Form.Control
                                        required
                                        type="text"
                                        placeholder=""
                                        defaultValue=""
                                        disabled={searchState.locationId == 1}
                                        isInvalid={!searchState.isCountryValid}
                                        onChange={(e: any) => {
                                            let clonedState = Object.assign({}, searchState);
                                            clonedState.country = e.target.value;
                                            clonedState.isCountryValid = clonedState.country.length > 0;
                                            setSearchState(clonedState);
                                        }}
                                    />
                                </Form.Group>
                                <Form.Group controlId="regionCtr">
                                    <Form.Label>Region / City:</Form.Label>
                                    <Form.Control
                                        required
                                        type="text"
                                        placeholder=""
                                        defaultValue=""
                                        disabled={searchState.locationId == 1}
                                        isInvalid={!searchState.isRegionValid}
                                        onChange={(e: any) => {
                                            let clonedState = Object.assign({}, searchState);
                                            clonedState.region = e.target.value;
                                            clonedState.isRegionValid = clonedState.region.length > 0;
                                            setSearchState(clonedState);
                                        }}
                                    />
                                </Form.Group>
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
                                {/* [TODO] How to render a list with multi-select ability? */}
                                <Form.Select aria-label="Default select example">
                                    <option value="1">English</option>
                                    <option value="2">Russia</option>
                                    <option value="3">Germany</option>
                                    <option value="4">Spain</option>
                                    <option value="5">Chinese</option>
                                    <option value="6">French</option>
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
                                {/* [TODO] How to make a slider with two bounds? */}
                                <Form.Select aria-label="">
                                    <option value="1">Any</option>
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
            <Button onClick={handleSubmit}>Search</Button>
            <SearchResult />
        </>
    );
}