import { createBrowserRouter, Navigate } from "react-router-dom";
import App from "./App";
import Main from "./components/Main/Main";
import CardsView from "./components/View/CardsView";
import Create from "./components/Create/Create";
import About from "./components/About/About";

export const router = createBrowserRouter([
    {
        path: '/',
        element: <App />,
        children: [
            {path: '', element: <Main />},
            {path: 'search', element: <Main />},
            {path: 'view', element: <CardsView />},
            {path: 'create', element: <Create />},
            {path: 'about', element: <About />},
            {path: 'server-error', element: <About />},
            {path: 'not-found', element: <About />},
            {path: 'profile', element: <About />},
            {path: 'signin', element: <About />},
            {path: '*', element: <Navigate replace to='not-found' />},
        ]
    }
]);