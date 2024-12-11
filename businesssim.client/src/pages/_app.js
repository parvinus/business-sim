import {NextUIProvider} from '@nextui-org/react';
import {useRouter} from 'next/router';

import PropTypes from 'prop-types';

const BusinessSim = ({ Component, pageProps }) => {
  const router = useRouter();
  
  return (
    <NextUIProvider navigate={router.push}>
      <Component {...pageProps} />
    </NextUIProvider>
  )
}

BusinessSim.displayName = 'BusinessSim';

BusinessSim.propTypes = {
  Component: PropTypes.elementType.isRequired,
  pageProps: PropTypes.object.isRequired,
};

export default BusinessSim;