import { Navbar, Container, Nav } from "react-bootstrap";

export default function Header() {
    return (

        <Navbar expand="lg" className="bg-body-tertiary" style={{marginBottom: "20px"}}>
            <Container>
                <Navbar.Brand href="#home">Person Finder</Navbar.Brand>
                <Navbar.Toggle aria-controls="basic-navbar-nav" />
                <Navbar.Collapse id="basic-navbar-nav">
                    <Nav className="me-auto">
                        <Nav.Link href="#home">Search</Nav.Link>
                        <Nav.Link href="#home">View</Nav.Link>
                        {/* [TO-DO] How to place separator? */}
                    </Nav>
                </Navbar.Collapse>
                <Navbar.Collapse id="basic-navbar-nav2" className="justify-content-end">
                    <Nav className="mr-auto">
                        {/* [TO-DO] To draw with CSS How to render an image button here? Does bootstrap have some standard button-images? */}
                        <Nav.Link href="#link" disabled={true}>Profile</Nav.Link>
                        <Nav.Link href="#link">Sign In</Nav.Link>
                        <Nav.Link href="#link">Sign Up</Nav.Link>
                    </Nav>
                </Navbar.Collapse>
            </Container>
        </Navbar>

    )
}