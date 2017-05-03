import React, { PropTypes } from 'react';
import { Pagination } from 'antd';

const Pager = ({ pageData, onChangePage }) => {
    let page = pageData.page + 1;
    const show = pageData.pageSize != pageData.count;
    return (
        <div>
            {show && <Pagination current={page} total={pageData.count} pageSize={pageData.pageSize} onChange={onChangePage} />}
        </div>
    );
};

Pager.propTypes = {
    pageData: PropTypes.object.isRequired,
    onChangePage: PropTypes.func.isRequired
};

export default Pager;