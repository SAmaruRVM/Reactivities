import React from 'react';
import { Duck } from './demo';


// this is a child component

interface Props {
  duck: Duck;
}


export default function DuckItem({ duck }: Props) { // TSX JSX (REACT)
  return (
    <div>
      { duck.name + ' with ' + duck.numberOfLegs + ' legs.' }
    </div>
  );
}