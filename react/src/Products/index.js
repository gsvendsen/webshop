import React from 'react'

import Product from '../Product/'

import './Products.css'

const Products = props => {

  return (
    <div className="products-container">
      {props.data.map(product => (<Product addToCart={props.addToCart} data={product} key={product.id} />))}
    </div>
  )
}

export default Products
