import { createRoot } from 'react-dom/client'
import './index.css'
import 'bootstrap/dist/css/bootstrap.min.css';
import { RouterProvider } from 'react-router-dom';
import { router } from './Routes.tsx';

createRoot(document.getElementById('root')!).render(
  <RouterProvider router={router} />
)
