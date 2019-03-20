import React from 'react'

import './Product.css'

const Product = props => {

  const productData = props.data;
  
  return (
    <div className="product-container">
      <img className="product-image" src={productData.image} alt={productData.description}></img>
      <div>
        <h3>{productData.name}</h3>
        <p>{productData.description}</p>
        <i>$ {productData.price}</i>
        <p>{productData.inventory} left in stock.</p>
        <button onClick={(e) => props.addToCart(e, productData)}>Add To Cart</button>
      </div>
    </div>
  )

}

export default Product
