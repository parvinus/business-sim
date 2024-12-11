// globals.css includes @tailwind directives
// adjust the path if necessary
import "@/styles/globals.css";
import {Providers} from "./providers";
import PropTypes from 'prop-types';

export default function RootLayout({children}) {
  return (
    <html lang="en" className='dark'>
      <body>
        <Providers>
          {children}
        </Providers>
      </body>
    </html>
)};


RootLayout.propTypes = {
    children: PropTypes.node.isRequired,
};
