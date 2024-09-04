import { useState } from "react";
import { Form, Button, Table } from "react-bootstrap";
import SearchResult from "./SerachResult";
import { SearchEntity } from "../../Entities/SearchEntity";
import http from "../../http";
import { SearchResultDto } from "../../DTOs/SearchResultDto";

export default function Main() {
    const [searchState, setSearchState] = useState<SearchEntity>(new SearchEntity());
    const [searchResult, setSearchResult] = useState<SearchResultDto []>();

    const handleSubmit = () => {
        let clonedState = searchState.clone();
        
        if (clonedState.isValid()) {
            http.Search.doSearch(searchState.toDto())
                .then(r => { setSearchResult(r); console.log('получили'); });
        }

        setSearchState(clonedState);
    };

    const handleAbilityCheckChanged = (event: any) => {
        let clonedState = searchState.clone();

        switch (event.target.id) {
            case "ability-1":
                clonedState.abilityChoice = 1;
                break;
            case "ability-2":
                clonedState.abilityChoice = 2;
                break;
            case "ability-3":
                clonedState.abilityChoice = 3;
                break;
        }

        setSearchState(clonedState);
    }

    const handleLocationCheckChanged = (event: any) => {
        let clonedState = searchState.clone();

        switch (event.target.id) {
            case "location-1":
                clonedState.locationChoice = 1;
                clonedState.validateCountry();
                clonedState.validateRegion();
                break;
            case "location-2":
                clonedState.locationChoice = 2;
                break;
        }

        setSearchState(clonedState);
    }

    return (
        <>
            <span style={{ color: 'midnightblue', fontSize: 20 }}>I am searching for a Person:</span>
            <hr />
            {/* ------------- Ability ----------- */}
            {/* [TO-DO] to eliminate. <center> Is this the correct way to center the content? */}
            <center>
                <Form className="mmm">
                    <Table>
                        <tr>
                            <td width={'20%'} rowSpan={3} style={{ textAlign: 'center' }}><span>who</span></td>
                            <td width={'10%'} rowSpan={3} style={{ paddingLeft: "18px" }}>

                                <Form.Check
                                    label="can teach "
                                    type="radio"
                                    name="abilityGroup"
                                    id="ability-1"
                                    checked={searchState.abilityChoice == 1}
                                    onChange={handleAbilityCheckChanged}
                                />
                                <Form.Check
                                    label="wants to learn "
                                    type="radio"
                                    name="abilityGroup"
                                    id="ability-2"
                                    checked={searchState.abilityChoice == 2}
                                    onChange={handleAbilityCheckChanged}
                                />
                                <Form.Check
                                    label="is interested in "
                                    type="radio"
                                    name="abilityGroup"
                                    id="ability-3"
                                    checked={searchState.abilityChoice == 3}
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
                                        let clonedState = searchState.clone();
                                        clonedState.abilityKeyWords = e.target.value;
                                        clonedState.validateAbility();
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
                            <td width={'10%'}><span>is located</span></td>
                            <td width={'20%'} style={{ paddingLeft: "18px" }}>
                                <Form.Check
                                    label="Anywhere"
                                    type="radio"
                                    name="locationGroup"
                                    id="location-1"
                                    checked={searchState.locationChoice == 1}
                                    onChange={handleLocationCheckChanged}
                                />
                                <Form.Check
                                    label="Specify"
                                    type="radio"
                                    name="locationGroup"
                                    id="location-2"
                                    checked={searchState.locationChoice == 2}
                                    onChange={handleLocationCheckChanged}
                                />
                                <Form.Group controlId="countryCtr">
                                    <Form.Label>Country:</Form.Label>
                                    <Form.Control
                                        required
                                        type="text"
                                        placeholder=""
                                        defaultValue=""
                                        disabled={searchState.locationChoice == 1}
                                        isInvalid={!searchState.isCountryValid}
                                        onChange={(e: any) => {
                                            let clonedState = searchState.clone();
                                            clonedState.country = e.target.value;
                                            clonedState.validateCountry();
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
                                        disabled={searchState.locationChoice == 1}
                                        isInvalid={!searchState.isRegionValid}
                                        onChange={(e: any) => {
                                            let clonedState = searchState.clone();
                                            clonedState.region = e.target.value;
                                            clonedState.validateRegion();
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
                            <td width={'10%'}><span>can speak</span></td>
                            <td width={'20%'}>
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
                            <td width={'10%'}><span>age is</span></td>
                            <td width={'20%'}>
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
            {/* <SearchResult results={searchResult} /> */}
        </>
    );
}