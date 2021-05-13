import { render, screen } from '@testing-library/react';
import { BrowserRouter } from 'react-router-dom';
import App from './App';

xtest('renders learn react link', () => {
  render(<App />);
  const linkElement = screen.getByText(/learn react/i);
  expect(linkElement).toBeInTheDocument();
});
