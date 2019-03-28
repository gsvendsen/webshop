import React from 'react'

import Product from '../Product/'

import './Products.css'

const Products = props => {

  return (
    <div className="products-container">
      {props.data.map((product, key) => (<Product key={key} addToCart={props.addToCart} data={product} />))}
    </div>
  )
}

export default Products
