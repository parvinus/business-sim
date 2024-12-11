import {NextUIProvider} from '@nextui-org/react';
import {useRouter} from 'next/navigation';
import PropTypes from 'prop-types';

export function Providers({children}) {
  const router = useRouter();

  return (
    <NextUIProvider navigate={router.push}>
      {children}
    </NextUIProvider>
  )
}

Providers.propTypes = {
  children: PropTypes.node.isRequired,
};