﻿var CardBranchName = React.createClass({
    render() {
        return <span style={{ marginLeft: 10 }}>
            <small className="text-muted">in branch { this.props.title }</small>
            { this.props.inRelease && <span>(RC)</span> }
        </span>;
    }
});