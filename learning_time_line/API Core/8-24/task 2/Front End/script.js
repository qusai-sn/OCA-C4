fetchProductsByCategory(1);
async function fetchCategories() {

    try {
        const response = await fetch('https://localhost:7011/api/Categories');
        const categories = await response.json();

        const dropdown = document.getElementById('categoryDropdown');
        categories.forEach(category => {
            const a = document.createElement('a');
            a.href = '#';
            a.textContent = category.categoryName;
            a.onclick = () => fetchProductsByCategory(category.categoryId);
            dropdown.appendChild(a);
        });

        const input_ddl = document.querySelectorAll('#ddl-categories');
        input_ddl.forEach(selectElement => {
            categories.forEach(category => {
                const option = document.createElement('option');
                option.value = category.categoryId;
                option.textContent = category.categoryName;
                selectElement.appendChild(option);
            });
        });

    } catch (error) {
        console.error('Error fetching categories:', error);
    }
}

async function fetchProductsByCategory(categoryId) {
    try {
        const response = await fetch(`https://localhost:7011/api/Products/category/${categoryId}`);
        const products = await response.json();
        const tableBody = document.getElementById('productGrid');
        tableBody.innerHTML = ''; 

        products.forEach(product => {
            const row = document.createElement('tr');
            row.innerHTML = `
                <th scope="row">${product.productId}</th>
                <td class="w-25">
                    <img src="${product.productImage}" class="img-fluid img-thumbnail" alt="${product.productName}">
                </td>
                <td>${product.productName}</td>
                <td>${product.description}</td>
                <td>$${product.price}</td>
                <td>
                    <button onclick="viewProductDetails(${product.productId})">View Details</button>
                </td>
            `;
            tableBody.appendChild(row);
        });
    } catch (error) {
        console.error('Error fetching products:', error);
    }
}

 

async function viewProductDetails(productId) {
    try {
        const response = await fetch(`https://localhost:7011/api/Products/${productId}`);
        const product = await response.json();
        const detailsContainer = document.getElementById('product-details-container');

        detailsContainer.innerHTML = `
            <div class="product-card">
                <img src="${product.productImage}" alt="${product.productName}">
                <div class="product-info">
                    <h2>${product.productName}</h2>
                    <p><strong>Description:</strong> ${product.description}</p>
                    <p><strong>Price:</strong> $${product.price}</p>
                    <div class="product-actions">
                        <label for="quantity">Quantity:</label>
                        <input type="number" id="quantity" name="quantity" min="1" value="1">
                        <button onclick="addToCart(${product.productId})">Add to Cart</button>
                    </div>
                </div>
            </div>
        `;

        // Scroll to the details section
        detailsContainer.scrollIntoView({ behavior: 'smooth' });

    } catch (error) {
        console.error('Error fetching product details:', error);
    }
}



async function addToCart(productId) {
    const quantity = document.getElementById('quantity').value;

    try {
        const addToCartResponse = await fetch('https://localhost:7011/api/Products/AddToCart', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                productId: productId,
                quantity: parseInt(quantity),
                userId: sessionStorage.id
            })
        });

        if (addToCartResponse.ok) {
            alert('Product added to cart successfully!');
            await getCartDetails(); // Optionally refresh the cart details
        } else {
            const errorMessage = await addToCartResponse.text();
            console.error('Failed to add product to cart:', errorMessage);
            alert('Failed to add product to cart: ' + errorMessage);
        }
    } catch (error) {
        console.error('Error adding product to cart:', error);
        alert('An error occurred while adding the product to the cart.');
    }
}

async function getCartDetails() {
    try {
        const response = await fetch('https://localhost:7011/getCartDetails');
        const cart = await response.json();
        console.log('User Cart:', cart);
    } catch (error) {
        console.error('Error fetching cart details:', error);
    }
}




function showUpdateForm(productId, productName, description, price, categoryId) {
    const updateForm = document.getElementById('updateForm');
    updateForm.innerHTML = `
        <div class="update-form-container">
            <h3>Update Product</h3>
            <form id="updateProductForm" enctype="multipart/form-data">
                <div class="form-group">
                    <label for="updateProductName">Product Name:</label>
                    <input type="text" id="updateProductName" name="productName" value="${productName}" required>
                </div>
                <div class="form-group">
                    <label for="updateDescription">Description:</label>
                    <textarea id="updateDescription" name="description" required>${description}</textarea>
                </div>
                <div class="form-group">
                    <label for="updatePrice">Price:</label>
                    <input type="number" id="updatePrice" name="price" value="${price}" required>
                </div>
                <div class="form-group">
                    <label for="updateCategory">Category:</label>
                    <select id="updateCategory" name="categoryId" required>
                        <!-- Categories will be populated here by JavaScript -->
                    </select>
                </div>
                <div class="form-group">
                    <label for="updateProductImage">Product Image:</label>
                    <input type="file" id="updateProductImage" name="productImage">
                </div>
                <button type="button" class="btn-update" onclick="UpdateProduct(${productId})">Update Product</button>
            </form>
        </div>
    `;

    // Populate categories in the update form
    fetchCategoriesForUpdate(categoryId);
}


async function fetchCategoriesForUpdate(selectedCategoryId) {
try {
const response = await fetch('https://localhost:7011/api/Categories');
const categories = await response.json();

const categorySelect = document.getElementById('updateCategory');
categories.forEach(category => {
    const option = document.createElement('option');
    option.value = category.categoryId;
    option.textContent = category.categoryName;
    if (category.categoryId === selectedCategoryId) {
        option.selected = true;
    }
    categorySelect.appendChild(option);
});
} catch (error) {
console.error('Error fetching categories:', error);
}
}

async function UpdateProduct(productId) {
const formData = new FormData(document.getElementById('updateProductForm'));

try {
const response = await fetch(`https://localhost:7011/api/Products/${productId}`, {
    method: 'PUT',
    body: formData
});

if (response.ok) {
    const contentType = response.headers.get("content-type");
    let product = null;
    if (contentType && contentType.indexOf("application/json") !== -1) {
        product = await response.json(); // Parse JSON only if content is JSON
    }
    alert('Product updated successfully!');
    console.log('Product updated:', product);
    // Optionally, refresh the product details view
    viewProductDetails(productId);
} else {
    const errorMessage = await response.text();
    console.error('Failed to update product:', errorMessage);
    alert('Failed to update product: ' + errorMessage);
}
} catch (error) {
console.error('Error updating product:', error);
alert('An error occurred while updating the product.');
}
}

async function addProductFromForm() {
    const formData = new FormData(document.getElementById('productForm'));

    // Get selected categoryId from dropdown
    const categoryId = document.getElementById('ddl-categories').value;
    formData.append('categoryId', categoryId);

    try {
        const response = await fetch('https://localhost:7011/api/Products/category/' + categoryId, {
            method: 'POST',

            body: formData
        });

        if (response.ok) {
            alert('Product added successfully!');
            document.getElementById('productForm').reset();
            fetchProductsByCategory(categoryId); // Optionally, refresh the product grid
        } else {
            const errorMessage = await response.text();
            alert('Failed to add product: ' + errorMessage);
        }
    } catch (error) {
        console.error('Error adding product:', error);
        alert('An error occurred while adding the product.');
    }
}

async function deleteProduct(productId) {
    try {
        const response = await fetch(`https://localhost:7011/api/Products/${productId}`, {
            method: 'DELETE'
        });

        if (response.ok) {
            alert('Product deleted successfully!');
            // Optionally, remove the row from the table
            const row = document.querySelector(`tr[onclick="viewProductDetails(${productId})"]`);
            if (row) {
                row.remove();
            }
            // Clear the details view
            document.getElementById('product-details-container').innerHTML = '';
        } else {
            const errorMessage = await response.text();
            alert('Failed to delete product: ' + errorMessage);
        }
    } catch (error) {
        console.error('Error deleting product:', error);
        alert('An error occurred while deleting the product.');
    }
}


async function addCategory() {
    const formData = new FormData();
    const categoryName = document.getElementById('categoryName').value;

    formData.append('CategoryName', categoryName);

    try {
        const response = await fetch('https://localhost:7011/api/Categories', {
            method: 'POST',
            body: formData
        });

        if (response.ok) {
            const category = await response.json();
            alert('Category added successfully! Category ID: ' + category.categoryId);
            document.getElementById('addCategoryForm').reset(); // Clear the form
            // Optionally, refresh the category list or perform other actions
        } else {
            const errorMessage = await response.text();
            alert('Failed to add category: ' + errorMessage);
        }
    } catch (error) {
        console.error('Error adding category:', error);
        alert('An error occurred while adding the category.');
    }
}


async function navigateToProductDetails(productId) {
    window.location.href = `./product-details.html?productId=${productId}`;
}

async function loadProductDetails() {
    const urlParams = new URLSearchParams(window.location.search);
    const productId = urlParams.get('productId');

    if (productId) {
        await viewProductDetails(productId);
    } else {
        console.error('No product ID found in URL.');
    }
}

window.onload = function() {
    const pageName = window.location.pathname.split('/').pop();
    
    if (pageName === 'product-listing.html') {
        fetchCategories();
    } else if (pageName === 'product-details.html') {
        loadProductDetails();
    }
};



// Fetch categories on page load
window.onload = function() {
    fetchCategories();
};
 
 