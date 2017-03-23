import React from 'react';
import { shallow } from 'enzyme';
import Title from './Title';

const props = {
  title: 'TitleTests'
};

describe('<Title />', () => {
  it('should be an h2 element', () => {
    const wrapper = shallow(<Title {...props} />);
    expect(wrapper.type()).toEqual('h2');
  });
});
