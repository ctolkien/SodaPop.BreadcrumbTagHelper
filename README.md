# SodaPop.BreadcrumbTagHelper

Generates schema.org compliant breadcrumbs.

## Install

```
dotnet install SodaPop.BreadcrumbTagHelper
```

Add the following to your `_ViewImports.cshtml` file:

```
@addTagHelper *, SodaPop.BreadcrumbTagHelper
```

## Usage

```html
<breadcrumb-list>
    <breadcrumb>
        <breadcrumb-anchor asp-action="index" asp-controller="home">
            Home
        </breadcrumb-anchor>
    </breadcrumb>
    <breadcrumb>
        <breadcrumb-anchor asp-action="about" asp-controller="home">
            About Us
        </breadcrumb-anchor>
    </breadcrumb>
</breadcrumb-list>
```

Also supports `Razor Pages`

```html
<breadcrumb-list>
    <breadcrumb>
        <breadcrumb-anchor asp-page="/index">
            Home
        </breadcrumb-anchor>
    </breadcrumb>
    <breadcrumb>
        <breadcrumb-anchor asp-page="/about">
            About Us
        </breadcrumb-anchor>
    </breadcrumb>
</breadcrumb-list>
```

## Rendered Output

```html
<ol itemscope="" itemtype="http://schema.org/BreadcrumbList">
    <li property="itemListElement" typeof="ListItem">
        <a property="item" typeof="WebPage" href="/">
            <span property="name">
                Home
           </span>
            <meta content="1" property="position"></a>
    </li>
    <li property="itemListElement" typeof="ListItem">
        <a property="item" typeof="WebPage" class="active" href="/About">
            <span property="name">
                About Us
            </span>
            <meta content="2" property="position"></a>
    </li>
</ol>```Things to note:* The `position` property will automatically be set based on it's position in the breadcrumb list
* A class of `active` will automatically be applied to the anchor if you're on a matching mvc route or razor page (would love help in making this more flexible)