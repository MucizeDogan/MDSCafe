using AutoMapper;
using DtoLayer.TestimonialDto;
using EntityLayer.Entities;

namespace Api.Mapping {
    public class TestimonialMapping :Profile {
        public TestimonialMapping() {
            CreateMap<Testimonial, ResultTestimonialDto>().ReverseMap();
            CreateMap<Testimonial, CreateTestimonialDto>().ReverseMap();
            CreateMap<Testimonial, UpdateTestimonialDto>().ReverseMap();
            CreateMap<Testimonial, GetTestimonialDto>().ReverseMap();
        }
    }
}
