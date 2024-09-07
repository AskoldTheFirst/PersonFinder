import { Navbar, Container, Nav } from "react-bootstrap";

export default function Header() {
    return (
        <Navbar expand="lg" className="bg-body-tertiary" style={{marginBottom: "20px"}}>
            <Container>
                <Navbar.Brand href="/search">Person Finder</Navbar.Brand>
                <Navbar.Toggle aria-controls="basic-navbar-nav" />
                <Navbar.Collapse id="basic-navbar-nav">
                    <Nav className="me-auto">
                        <Nav.Link href="/search">Search</Nav.Link>
                        <Nav.Link href="/create" disabled={true}>Create</Nav.Link>
                        <Nav.Link href="/view" disabled={false}>View</Nav.Link>
                    </Nav>
                </Navbar.Collapse>
                <Navbar.Collapse id="basic-navbar-nav2" className="justify-content-end">
                    <Nav className="mr-auto">
                        <Nav.Link href="/profile" disabled={true}>Profile</Nav.Link>
                        <Nav.Link href="/signin">Sign In</Nav.Link>
                        <Nav.Link href="/signup">Sign Up</Nav.Link>
                    </Nav>
                </Navbar.Collapse>
            </Container>
        </Navbar>
    )
}