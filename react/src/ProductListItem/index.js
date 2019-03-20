import React from 'react'

import './ProductListItem.css'

const ProductListItem = props => {

  const productData = props.data
  console.log(productData)
  return (
    <div className="product-list-item">
      <img className="product-thumbnail" src={productData.image} />
      <div className="product-list-info">
        <p>{productData.name}</p>
        <p> ${productData.price}</p>
      </div>
    </div>
  )
}

export default ProductListItem
